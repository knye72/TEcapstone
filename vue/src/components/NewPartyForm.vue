<template>
  <div class="border new-party-form">
    <h1 id = "title">Make a Party</h1>
    <form class = "col-6" v-on:submit.prevent="addNewParty" v-show="showForm === true">
      <div class="form-element ">
        <label for="name">Name:</label>
        <input
          class="input-field"
          id="name"
          type="text"
          v-model="party.name"
          placeholder="Party Name"
        />
      </div>

      <div class="form-element">
        <label for="description">Description:</label>
        <input 
          class="input-field"
          id="description"
          type="text"
          v-model="party.description"
          placeholder="Party Description"
        />
      </div>

      <div class="form-element">
        <label for="date">Date:</label>
        --><!--// TODO Make this a date picker and bind for="date" again-->
        <input
          class="input-field"
          id="date"
          type="date"
          v-model="party.date"
          placeholder="Party Date"
        />
      </div>

      <div class="form-element">
        <label for="time">Select a time:</label>
        <input type="time" id="time" name="time" v-model="party.time" placeholder="Party Time" />
      </div>

      <div class="form-element">
        <label for="location">Location:</label>
        <!--// TODO Make this a location picker -->
        <input
          class="input-field"
          id="location"
          type="text"
          v-model="party.location"
          placeholder="Ex. Cleveland OH"
        />
      </div>
          <div class="form-element">
        <label for="location">Invite Code:</label>
        <input
          class="input-field"
          id="party_invite_code"
          type="text"
          v-model="party.partyInviteCode"
          placeholder="invitation code word"
        />
      </div>
      <input type="submit" value="Save" class="btn btn-success" />

    </form>
    <div v-if="showForm === false">
      <h2>Party Created!</h2>
      <p>Click the button below to view your parties.</p>
      <router-link to="/dashboard" class="btn btn-default"
        >View all parties</router-link
      >
    </div>
  </div>
</template>

<script>
import NewPartyService from "../services/PartyService.js";

export default {
  name: "new-party-form",
  data() {
    return {
      party: {
        owner: 1, //TODO make this current user_id
      },
      showForm: true,
    };
  },
  methods: {
    addNewParty() {
      this.party.owner = this.$store.state.user.id;
      NewPartyService.create(this.party)
        .then((response) => {
          console.log(response);
          this.$emit("party-created", response.data);
          this.party = response.data;
        })
        .catch((error) => {
          console.log(error);
        });
      this.party = { owner: 1 }; //empty out the review
      this.$store.commit("ADD_NEW_PARTY", this.party);
      this.showForm = false; //hide the form
    },
  },
};
</script>

<style>
#title
{
  margin: 5px;
  margin-bottom: 15px;
}
.form-element
{
  margin: 5px;
}
.input-field
{
  display: flex;
}

</style>