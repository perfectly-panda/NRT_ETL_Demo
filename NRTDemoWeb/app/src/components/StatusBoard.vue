<template>
   <v-container grid-list-md text-xs-center>
        <v-layout row wrap float>
            <v-flex xs2>
                <v-card>
                    <v-card-title>
                        On Location:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-text class="display-4">{{getCount(1,trucks)}}</v-card-text>
                </v-card>
            </v-flex>
            <v-flex xs2>
                <v-card>
                    <v-card-title>
                        On Dock:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-text class="display-4">{{getCount(2,trucks)}}</v-card-text>
                </v-card>
            </v-flex>
            <v-flex xs2>
                <v-card>
                    <v-card-title>
                        Unloading:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-text class="display-4">{{getCount(3,trucks)}}</v-card-text>
                </v-card>
            </v-flex>
            <v-flex xs2>
                <v-card>
                    <v-card-title>
                        Unloading Complete:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-text class="display-4">{{getCount(4,trucks)}}</v-card-text>
                </v-card>
            </v-flex>
            <v-flex xs2>
                <v-card>
                    <v-card-title>
                        Left Dock:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-text class="display-4">{{getCount(5,trucks)}}</v-card-text>
                </v-card>
            </v-flex>
            <v-flex xs2>
                <v-card v-if="trucks">
                    <v-card-title>
                        Total On Site:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-text class="display-4">{{trucks.length}}</v-card-text>
                </v-card>
            </v-flex>
            <v-flex xs4>
                <v-card v-if="mostRecent">
                    <v-card-title>
                        Last Event:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-list dense>
                        <v-list-tile>
                        <v-list-tile-content>Truck Id:</v-list-tile-content>
                        <v-list-tile-content class="align-end">{{ mostRecent.truckId }}</v-list-tile-content>
                        </v-list-tile>
                    </v-list>
                    <v-list dense>
                        <v-list-tile>
                        <v-list-tile-content>On Location:</v-list-tile-content>
                        <v-list-tile-content class="align-end">{{mostRecent.enterDCTime | formatDate }}</v-list-tile-content>
                        </v-list-tile>
                    </v-list>
                    <v-list dense>
                        <v-list-tile>
                        <v-list-tile-content>OnDock:</v-list-tile-content>
                        <v-list-tile-content class="align-end">{{mostRecent.dockStartTime | formatDate }}</v-list-tile-content>
                        </v-list-tile>
                    </v-list>
                    <v-list dense>
                        <v-list-tile>
                        <v-list-tile-content>Unloading:</v-list-tile-content>
                        <v-list-tile-content class="align-end">{{mostRecent.unloadStartTime | formatDate }}</v-list-tile-content>
                        </v-list-tile>
                    </v-list>
                    <v-list dense>
                        <v-list-tile>
                        <v-list-tile-content>Unload Complete:</v-list-tile-content>
                        <v-list-tile-content class="align-end">{{mostRecent.unloadStopTime | formatDate }}</v-list-tile-content>
                        </v-list-tile>
                    </v-list>
                    <v-list dense>
                        <v-list-tile>
                        <v-list-tile-content>Left Dock:</v-list-tile-content>
                        <v-list-tile-content class="align-end">{{mostRecent.dockEndTime | formatDate }}</v-list-tile-content>
                        </v-list-tile>
                    </v-list>
                    <v-list dense>
                        <v-list-tile>
                        <v-list-tile-content>Left Location:</v-list-tile-content>
                        <v-list-tile-content class="align-end">{{mostRecent.leaveDCTime | formatDate }}</v-list-tile-content>
                        </v-list-tile>
                    </v-list>
                </v-card>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
import moment from 'moment'
import Timer from './Timer'

export default {
  name: 'StatusBoard',
  components: {
    Timer
  },
  props: {
    trucks: {
      truckId: Number
    },
    mostRecent:  null
  },
  methods: {
      getCount(status, trucks){
          var count = 0;
          if(trucks){
            for(var i = 0; i <trucks.length; i++){
                if(trucks[i].status == status){
                    count++;
                }
            }
          }
          return count;
      }
  }
}
</script>