import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if (currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    currentUserId: {},
    currentParty: {},
    currentParties: [],
    restaurant: [

    ],
    current_likes: [],
    current_dislikes: [],
    user_likes_dictionary: []
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user', JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    SET_CURRENT_PARTIES(state, parties) {
      state.currentParties = parties;
    },

    UPDATE_FILTER(state, filter) {
      state.filter = filter;
    },

    ADD_NEW_PARTY(state, party) {
      console.log("ADDING " + party + " to the currentParties in the state");
      state.currentParties.shift(party);
    },

    SET_CURRENT_PARTY(state, party) {
      state.currentParty = party;
    },
    
    ADD_LIKE(state, restaurant) {
      state.current_likes.push(restaurant);
    },

    ADD_DISLIKE(state, restaurant) {
      state.current_dislikes.push(restaurant);
    },

    CLEAR_LIKES(state) { 
      state.current_likes = []; 
      state.current_dislikes = [];
    },
    ADD_USER_LIKES_ENTRY(state, entry) {
      state.user_likes_dictionary.push(entry); 
    } 
  }
})
