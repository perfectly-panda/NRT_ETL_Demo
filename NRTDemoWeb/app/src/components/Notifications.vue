<template>
<div>
    <v-list-tile v-for="note in notifications" :key="note.messageText" class="truckItem mb-4">   
    <v-list dense>
        <v-list-tile-content>
        <v-list-tile-title>
            {{note.level}}
        </v-list-tile-title>
        <v-list-tile-sub-title>
            {{note.messageText}}
        </v-list-tile-sub-title>
        </v-list-tile-content>
    </v-list>
    </v-list-tile>
    </div>
</template>

<script>
export default {
  name: 'Notifications',
  props: {
    notifications: null
  },
  data: function(){
  }
}
</script>