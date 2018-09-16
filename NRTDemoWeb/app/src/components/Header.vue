<template>
<div v-if="note">
    <v-container 
        text-uppercase
        justify-center
        v-bind:class="note.level">
        <v-layout row wrap>
            <v-flex xs12>
                {{note.level}}  -  {{note.messageText}}
            </v-flex>
        </v-layout>
    </v-container>
</div>
</template>

<script>
export default {
  name: 'Notifications',
  props: {
    note: null
  }
}
</script>

<style>
 .Error {
     background-color: #B71c1c;
 }

 .Warn {
     background-color: #F9A825;
 }

 .Info {
     background-color: #FAFAFA;
     color: #424242;
 }
</style>