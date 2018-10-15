There are serveral Azure services involved in this project:

Base:
1) Azure Functions
2) Event Grid
3) Event Hub*
4) Azure SQL

Real time analysis:
5) Stream Analytics*
6) Power BI

Real Time website:
7) App Services

* These services do cost money any time the are running, even if you are not consuming any resources.

Project Setup:

I suggest starting by setting up the Azure database, Event Grid and Event Hub first, as you'll need those connection strings to deploy the functions app and the webpage.

The schema for the Azure DB is: 

CREATE TABLE Settings (
  SettingName varchar(50) NOT NULL,
  SettingValue varchar(50) NOT NULL
)

INSERT INTO Settings (SettingName
, SettingValue)
  VALUES ('PalletsPerHour', 20)
  , ('TrucksPerHour', 10)
  , ('MovementTime', 5)

CREATE TABLE Trucks (
  TruckId int NOT NULL IDENTITY (1, 1),
  Pallets int NOT NULL,
  EnterDCTime datetime NULL,
  DockStartTime datetime NULL,
  UnloadStartTime datetime NULL,
  UnloadStopTime datetime NULL,
  DockEndTime datetime NULL,
  LeaveDCTime datetime NULL
)


There is one Event Hub and two Event Grid paths. The names don't matter, but the first Grid and the Hub are for truck events, and the second grid is for notifications. The function "HubToGrid" handles connecting the two.


If you want to run the Functions app locally, youll need to populated the local.settings.json file with these connection strings. The Hub and Grids go into the "Values" section: 
    "EventHub": "", 
    "EventGridUrl": "",
    "EventGridKey": "",
    "NotificationUrl": "",
    "NotificationKey": ""

Under "ConnectionStrings" add an entry called "DatabaseConnection" and add the connection string for your Azure DB.

Once you deploy this to the portal, everything in the "Values" section will need to be added to the Application Settings, and the DB connection goes in the Connection Strings. These are not transfered during the standard publish option from Visual Studio.

You will also need to configur the "NewTruckNotifications" function to the truck event grid. Once the app is deployed, you can navigate to the function in the portal, and there will be an option to Add Event Grid subscription. This should walk you through the process on hooking them together.


The web app only has two entries to add to appsettings.json: "DatabaseConnection" and "EventHub". These do populate when you deploy the web app.

Next, connect the Event Grids to the web app and functions. In the portal go to each grid app and create a new receiver. The URL for the truck events should be https://{yoursite}.azurewebsites.net/api/EventGridEventHandler. The one to receive notifications is /api/NotificationHandler.


If you choose to use Stream Analytics, add another receiver to your Event Hub and connect to it from the Stream Analytics blade. To connect to Power BI, create a new output and log in to your Power BI account. Stream Analytics will handle setting up the dataset in Power BI the first time the stream runs.


You should be able to make changes to the Functions app and simply redeploy, and the same for the web API section. 

If you want to make changes to the Vue front end, the code is in the app folder in the web project. I highly suggest that you install the Vue CLI if you want to work on the front end, as it makes Vue development much easier via the Vue serve command. This starts up a Node server and watches your code for changes, auto rebuilding as you work.

The vue.config.js file specifies that the wwwroot directory that .NET Core uses to serve webpages. However, I was having trouble to getting it to build from my global Vue CLI installation. With a command line pointed at the app directory, running "node .\node_modules\@vue\cli-service\bin\vue-cli-service.js build" allowed me to successfully build the project. This uses the local copy of Vue, so it should work even if you don't install the CLI- it is only dependant on Node.


