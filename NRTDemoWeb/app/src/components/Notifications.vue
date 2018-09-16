<template>
<div>
    <v-list dense xs12 class="overflow-hidden">
        <v-list-tile 
            v-for="note in notifications" 
            :key="note.messageText" 
            v-bind:class="note.level + '2'">
            <v-list-tile-content>
                <v-list-tile-title>
                    {{note.level}}  -  {{note.messageText}}
                </v-list-tile-title>
            </v-list-tile-content>
        </v-list-tile>
    </v-list>
    </div>
</template>

<script>
export default {
  name: 'Notifications',
  props: {
    notifications: null
  }
}
</script>

<style>
    .Error2 {
        color: #B71c1c;
        font-weight: bold;
    }

    .Warning2 {
        color: #F9A825;
    }

    .Info2 {
        color: #FAFAFA;
    }
</style>