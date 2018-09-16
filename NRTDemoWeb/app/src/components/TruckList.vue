<template>
  <div>
    <v-list three-line dense>
      <v-list-tile>
        <v-list-tile-title class="title">
          Active Trucks
        </v-list-tile-title>
      </v-list-tile>
      <v-list-tile v-for="truck in trucks" :key="truck.truckId" class="truckItem mb-4">
         <v-flex xs12>
        <v-card color="deep-purple darken-4" class="pa-2">
            <v-list-tile-content>
              <v-list-tile-title>Truck Id: {{truck.truckId}}, {{truck.pallets}} Pallets</v-list-tile-title>
              <v-list-tile-sub-title>Last Event: 
                <span v-if="truck.dockEndTime != null">Left Dock at {{truck.dockEndTime | formatDate }}</span>
                <span v-else-if="truck.unloadStopTime != null">Unload completed at {{truck.unloadStopTime | formatDate }}</span>
                <span v-else-if="truck.unloadStartTime != null">Unload began at {{truck.unloadStartTime | formatDate }}</span>
                <span v-else-if="truck.dockStartTime != null">Entered dock at {{truck.dockStartTime | formatDate }}</span>
                <span v-else>Entered DC at {{truck.enterDCTime | formatDate }}</span>
              </v-list-tile-sub-title>
              <v-list-tile-sub-title v-if="truck.unloadStartTime != null && truck.unloadStopTime == null">
                <span>Unload Time: <timer v-bind:countFrom="truck.unloadStartTime"></timer></span>
              </v-list-tile-sub-title>
              <v-list-tile-sub-title>
                Total Time: <timer v-bind:countFrom="truck.enterDCTime"></timer>
              </v-list-tile-sub-title>
              <v-divider light v-if="true"></v-divider>
              <v-spacer></v-spacer>
            </v-list-tile-content>
        </v-card>
         </v-flex>
      </v-list-tile>
  </v-list>
</div>
</template>

<script>
import moment from 'moment'
import Timer from './Timer'

export default {
  name: 'TruckList',
  components: {
    Timer
  },
  props: {
    trucks: {
      truckId: Number
    }
  }
}
</script>

<style>
</style>