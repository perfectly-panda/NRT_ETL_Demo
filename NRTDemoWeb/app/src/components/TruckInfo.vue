<template>
    <v-card v-if="truck && show">
        <v-card-title class="headline">
            {{title}}
        </v-card-title>
        <v-divider></v-divider>
        <v-list dense>
            <v-list-tile>
                <v-list-tile-content>Truck Id:</v-list-tile-content>
                <v-list-tile-content class="align-end">{{truck.truckId }}</v-list-tile-content>
            </v-list-tile>
             <v-list-tile>
                <v-list-tile-content>Pallets:</v-list-tile-content>
                <v-list-tile-content class="align-end">{{truck.pallets }}</v-list-tile-content>
            </v-list-tile>
            <v-list-tile>
                <v-list-tile-content>On Location:</v-list-tile-content>
                <v-list-tile-content class="align-end">{{truck.enterDCTime | formatDate }}</v-list-tile-content>
            </v-list-tile>
            <v-list-tile>
                <v-list-tile-content>OnDock:</v-list-tile-content>
                <v-list-tile-content class="align-end">{{truck.dockStartTime | formatDate }}</v-list-tile-content>
            </v-list-tile>
            <v-list-tile>
               <v-list-tile-content>Unloading:</v-list-tile-content>
                <v-list-tile-content class="align-end">{{truck.unloadStartTime | formatDate }}</v-list-tile-content>
            </v-list-tile>
            <v-list-tile>
                <v-list-tile-content>Unload Complete:</v-list-tile-content>
                <v-list-tile-content class="align-end">{{truck.unloadStopTime | formatDate }}</v-list-tile-content>
            </v-list-tile>
            <v-list-tile>
                <v-list-tile-content>Left Dock:</v-list-tile-content>
                <v-list-tile-content class="align-end">{{truck.dockEndTime | formatDate }}</v-list-tile-content>
            </v-list-tile>
            <v-list-tile>
                <v-list-tile-content>Left Location:</v-list-tile-content>
                <v-list-tile-content class="align-end">{{truck.leaveDCTime | formatDate }}</v-list-tile-content>
            </v-list-tile>
            <v-list-tile class="mb-2">
                <v-list-tile-content>
                    <v-btn 
                        color="info" 
                        block
                        @click="onMove(truck)"
                    >
                        Move Truck
                    </v-btn>
                </v-list-tile-content>
            </v-list-tile>
        </v-list>
    </v-card>
</template>

<script>
export default {
  name: 'TruckInfo',
  props: {
    truck: null,
    title: null
  },
  methods:
  {
      onMove(value){
            this.$emit('moveTruck', value);
        }
  },
  data: function() {
      return {
          show: true
      }
  }
}
</script>

<style>
</style>