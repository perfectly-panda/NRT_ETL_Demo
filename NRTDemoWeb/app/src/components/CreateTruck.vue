<template>
    <v-card>
        <v-card-title class="headline">
            Create New:
        </v-card-title>
        <v-divider></v-divider>
        <v-list dense>
            <v-form v-model="valid">
                <v-list-tile>
                        <v-list-tile-content>
                            <v-text-field
                            v-model="pallets"
                            label="Pallets"
                            required
                            ></v-text-field>
                    </v-list-tile-content>
                </v-list-tile>
                <v-list-tile class="mb-2">
                    <v-list-tile-content>
                        <v-btn
                        :disabled="!valid"
                        @click="create"
                        block
                        color="success"
                        >
                            Submit
                        </v-btn>
                    </v-list-tile-content>
                </v-list-tile>
            </v-form>
        </v-list>
    </v-card>
</template>

<script>
import axios from 'axios'

export default {
  name: 'CreateTruck',
  methods: {
      create(){
          if(this.pallets){
            console.log(this.pallets);
            var url = 'https://nrtdemoweb.azurewebsites.net/api/truck/create/' + this.pallets;
            axios
                .get(url);
          }
      }
  },
  data: function(){
      return {
          pallets: null,
          valid: false
      }
  }
}
</script>