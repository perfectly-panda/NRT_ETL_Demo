<template>
   <v-container grid-list-md text-xs-center>
        <v-layout row wrap float>
            <v-flex xs2>
                <v-card>
                    <v-card-title class="headline">
                        On Location:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-text class="display-2">{{getCount(1,trucks)}}</v-card-text>
                </v-card>
            </v-flex>
            <v-flex xs2>
                <v-card>
                    <v-card-title class="headline">
                        On Dock:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-text class="display-2">{{getCount(2,trucks)}}</v-card-text>
                </v-card>
            </v-flex>
            <v-flex xs2>
                <v-card>
                    <v-card-title class="headline">
                        Unloading:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-text class="display-2">{{getCount(3,trucks)}}</v-card-text>
                </v-card>
            </v-flex>
            <v-flex xs2>
                <v-card>
                    <v-card-title class="headline">
                        Unload Complete:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-text class="display-2">{{getCount(4,trucks)}}</v-card-text>
                </v-card>
            </v-flex>
            <v-flex xs2>
                <v-card>
                    <v-card-title class="headline">
                        Left Dock:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-text class="display-2">{{getCount(5,trucks)}}</v-card-text>
                </v-card>
            </v-flex>
            <v-flex xs2>
                <v-card v-if="trucks">
                    <v-card-title class="headline">
                        Total On Site:
                    </v-card-title>
                    <v-divider></v-divider>
                    <v-card-text class="display-2">{{trucks.length}}</v-card-text>
                </v-card>
            </v-flex>
             <v-flex xs4>
                <CreateTruck>
                </CreateTruck>
            </v-flex>
            <v-flex xs4 v-if="mostRecent">
                <TruckInfo 
                    v-bind:truck="mostRecent"
                    v-bind:title="'Last Event:'"
                    v-on:selectTruck="onSetActive"
                    v-on:moveTruck="onMove">
                </TruckInfo>
            </v-flex>
            <v-flex xs4 v-if="activeTruck">
                <TruckInfo 
                    v-bind:truck="activeTruck"
                    v-bind:title="'Focused Truck:'"
                    v-on:selectTruck="onSetActive"
                    v-on:moveTruck="onMove">
                </TruckInfo>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
import moment from 'moment'
import Timer from './Timer'
import TruckInfo from './TruckInfo'
import CreateTruck from './CreateTruck'

export default {
  name: 'StatusBoard',
  components: {
    Timer,
    TruckInfo,
    CreateTruck
  },
  props: {
    trucks: {
      truckId: Number
    },
    mostRecent:  null,
    activeTruck: null
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
        },
        onSetActive(value){
            this.$emit('onSetActive', value);
        },
        onMove(value){
            this.$emit('moveTruck', value);
        }
    }
}
</script>