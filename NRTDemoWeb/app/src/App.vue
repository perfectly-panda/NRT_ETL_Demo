<template>
  <v-app id="app" dark>
            <v-navigation-drawer fixed right width="375" app>
            <TruckList v-bind:trucks="trucks" ></TruckList>
        </v-navigation-drawer>
    <v-content>
        <v-container>
          <StatusBoard v-bind:trucks="trucks" v-bind:mostRecent="mostRecent"></StatusBoard>
        </v-container>
      </v-content>
    <v-footer height="250">
      <v-layout>
        <Notifications v-bind:notifications="notifications"></Notifications>
        </v-layout>
    </v-footer>
  </v-app>
</template>

<script>
import TruckList from './components/TruckList.vue'
import StatusBoard from './components/StatusBoard.vue'
import Notifications from './components/Notifications.vue'

import axios from 'axios'

const signalR = require("@aspnet/signalr");

export default {
  name: 'app',
  components: {
    TruckList,
    StatusBoard,
    Notifications
  },
  mounted: function() {
    axios
      .get('https://nrtdemoweb.azurewebsites.net/api/truck')
      .then(response => (this.trucks = response.data));

    var self = this;
    var truckHub = new signalR.HubConnectionBuilder()
        .withUrl("https://nrtdemoweb.azurewebsites.net/truckHub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    truckHub.start().catch(err => console.error(err.toString()));
    truckHub.on("SendMessage", (truckId, truck) => {
      self.processTruck(truckId, truck)
    });

    var notificationHub = new signalR.HubConnectionBuilder()
        .withUrl("https://nrtdemoweb.azurewebsites.net/notificationHub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    notificationHub.start().catch(err => console.error(err.toString()));
    notificationHub.on("SendMessage", (notification) => {
      self.processNotification(notification)
    });
  },
  data: function(){
    return {
      trucks: null,
      mostRecent: null,
      notifications: null,
      lastNotification: null
    }
  },
  methods: {
    processTruck(truckId, truck){
        for(var i = 0; i < this.trucks.length; i++){
        if(this.trucks[i].truckId == truckId){
          if(truck.leaveDCTime){
            this.trucks.splice( i, 1);
          }
          else{
            this.trucks.splice( i, 1, truck);
          }
          this.mostRecent = truck;
          this.mostRecent.truckId = truckId;
          return;
        }
      }
      this.trucks.push(truck);

      this.mostRecent = truck;
      this.mostRecent.truckId = truckId;
    },
    processNotification(notification){
      console.log(notification);
      if(this.notifications){
        while(this.notifications.length > 4){
          this.notifications.shift();
        }
      }

      if(this.notifications){
             this.notifications.push(notification);
      }
      else{
        this.notifications = [notification];
      }

      this.lastNotification = notification;
    }
  }
}
</script>

<style>
</style>
