<template>
<!--  Billing dearils inserting page -->
    <div class="st1">
        <b-container fluid>
        <!-- <Logo /> -->
        <h1 class="title">testapplication - E_COM</h1>
        <div class="mt-3">
            <b-button-group>       
            <b-button variant="info">Account Infomation</b-button>
            <b-button variant="success">Billing Address</b-button>
            <b-button variant="info">Shipping Address</b-button>
            </b-button-group>
        </div>
        <form v-on:submit.prevent="submitForm">
             <div class="form-group">
                 <label for="BillAddress1">Billing Address Line 1 *</label>
                 <input type="text" class="form-control" id="BillAddress1" placeholder="Your name" v-model="form.BillAddress1" required>
            </div>             
            <div class="form-group">
                <label for="BillAddress2">Billing Address Line 2</label>
                <input type="text" class="form-control" id="BillAddress2" placeholder="Business name" v-model="form.BillAddress2">
            </div>
             <div class="form-group">
                <label for="BillCity">City *</label>
                <input type="text" class="form-control" id="BillCity" placeholder="Phone Code" v-model="form.BillCity" required>
            </div>
            <div class="form-group">
                <button class="btn btn-primary">Next</button>
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
                BillAddress1: '',
                BillAddress2: '',
                BillCity: '',
                // district: '',
             }
        }
    },
    methods:{
        submitForm(){// button click form submit method, axios for post data
            alert("Do you wish to proceed!");  
            axios.post('https://localhost:44394/api/billings', this.form)
                 .then((res) => {
                     //Perform Success Action
                  

                 })
                 .catch((error) => {
                        if (error.response.status == 401){
                       alert("Error Please check the connection");  
                
                         }                
                 }).finally(() => {
                     //Perform action in always
                       this.$router.push('/ShippingPage')
                 });
                 

        }
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

