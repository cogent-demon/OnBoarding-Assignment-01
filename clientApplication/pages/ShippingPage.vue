<template>
<!--  Shipping dearils inserting page -->
    <div class="st1">
        <b-container fluid>
        <!-- <Logo /> -->
        <h1 class="title">testapplication - E_COM</h1>
        <div class="mt-3">
            <b-button-group>       
            <b-button variant="info">Account Infomation</b-button>
            <b-button variant="info">Billing Address</b-button>
            <b-button variant="success">Shipping Address</b-button>
            </b-button-group>
        </div>
        <form v-on:submit.prevent="submitForm">
            <div class="form-group">
                <label for="ShipAddress1">Address Line 1 *</label>
                <input type="text" class="form-control"
                 id="ShipAddress1" 
                 placeholder="Your name" 
                 v-model="form.ShipAddress1" 
                 required>
            </div>
            <div class="form-group">
                <label for="ShipAddress2">Address Line 2</label>
                <input type="text" 
                class="form-control" 
                id="ShipAddress2" 
                placeholder="Your name" 
                v-model="form.ShipAddress2">
            </div>
            <div class="form-group">
                <label for="ShipCity">City *</label>
                <input type="text" class="form-control" id="ShipCity" placeholder="Your name" v-model="form.ShipCity" required>
            </div>
            <!-- <div class="form-group">
                <label for="district">District</label>
                <select name="district" class="form-control" id="district" v-model="form.district" required>
                    <option value="negombo">negombo</option>
                    <option value="colombo">colombo</option>
                    <option value="galle">galle</option>
                    <option value="jaffna">jaffna</option>
                    <option value="kaluthara">kaluthara</option>
                </select>
            </div>   -->
            <div class="form-group">
                <label for="Request">Special Register Requests</label>
                <textarea name="Request" class="form-control" id="Request" rows="3"
                                v-model="form.Request"></textarea>
            </div>  
            <div class="form-group">
                <label for="formControlRange">whould you like to recive a monthly email? *</label><br />
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="radio" name="yes" id="yes" value="yes"
                            v-model="form.EmailSub">
                    <label class="form-check-label" for="mail">Yes</label>
                </div>
                <div class="form-check form-check-inline">
                    <input class="form-check-input" type="radio" name="mail" id="no" value="no"
                            v-model="form.EmailSub">
                    <label class="form-check-label" for="mail">No</label>
                </div>
            </div>
            <div class="form-group">
                <button class="btn btn-primary">Submit</button>
            </div>
        </form>
        </b-container>
    </div>
</template>
<script>
import axios from 'axios';

export default {
    name: 'PostFormAxios',
    data(){
        return{
            form: {
                ShipAddress1: '',
                ShipAddress1: '',
                ShipCity: '',
               // district: '',
                Request: '',
                EmailSub: '',
            }
        }
    },
    methods:{
        submitForm(){
            
            axios.post('https://localhost:44394/api/shippngs', this.form)  //axios post method to send data.
                 .then((res) => {
                     
                     //Perform Success Action
                 })
                 .catch((error) => {
                    alert("Error Please check the connection");  
                 }).finally(() => {
                     //Perform action in always
                      alert("Record Submited Successfully!"); 
                       this.$router.push('./')
                     // data();

                 });
                 

        },

             
       
	} 

}
</script>
<style>
.b-container {
  margin-block: 50;
  margin-top: 100px;
  background-color: bisque;
}
.container {
  margin: 0 auto;
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
}

.title {
  font-family: 'Quicksand', 'Source Sans Pro', -apple-system, BlinkMacSystemFont,
    'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif;
  display: block;
  font-weight: 300;
  font-size: 100px;
  color: #35495e;
  letter-spacing: 1px;
  align-content: center;
}

.subtitle {
  font-weight: 300;
  font-size: 42px;
  color: #526488;
  word-spacing: 5px;
  padding-bottom: 15px;
}

.links {
  padding-top: 15px;
}
.st1 {
  margin: 50px;
}
</style>

