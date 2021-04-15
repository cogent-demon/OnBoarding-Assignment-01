<template>
<!--  Account deatils inserting page -->
    <div class="st1">
        <b-container fluid>
        <!-- <Logo /> -->
        <h1 class="title">testapplication - E_COM</h1>
        <div class="mt-3">
            <b-button-group>       
            <b-button variant="success">Account Infomation</b-button>
            <b-button variant="info">Billing Address</b-button>
            <b-button variant="info">Shipping Address</b-button>
            </b-button-group>
        </div>
        <form v-on:submit.prevent="submitForm">

            <div class="form-group">
                 <label for="name">Name *</label>
                 <input type="text" class="form-control" id="name" placeholder="Your name" v-model="form.name" required>
            </div>             
            <div class="form-group">
                <label for="B_Name">Business Name</label>
                <input type="text" class="form-control" id="bname" placeholder="Business name" v-model="form.bname">
            </div>
            <div class="form-group">
                <label for="phonecode">phone code *</label>
                <input type="number" class="form-control" id="phonecode" placeholder="Phone Code" v-model="form.phonecode" required>
            </div>
            <div class="form-group">
                <label for="phonenumber">Phone number *</label>
                <input type="number" class="form-control" id="phonenumber" placeholder="Phone Number" v-model="form.phonenumber" required>
            </div>
            <div class="form-group">
                 <label for="accaddress1">Address1 *</label>
                 <input type="text" class="form-control" id="accaddress1" placeholder="Your Address Line 2" v-model="form.accaddress1" required>
            </div> 
            <div class="form-group">
                <label for="AccAddress2">Address2</label>
                <input type="text" class="form-control" id="AccAddress2" placeholder="Your Address line 2" v-model="form.AccAddress2">
            </div>
            <div class="form-group">
                <label for="AccCity">City *</label>
                <input type="text" class="form-control" id="AccCity" placeholder="Your City" v-model="form.AccCity" required>
            </div>
            <div class="form-group">
                <label for="district">District *</label>
                <select name="district" class="form-control" id="district" v-model="form.AccDistrict" required>
                    <option value="Puththalam">Puththalam</option>
                    <option value="Colombo">Colombo</option>
                    <option value="Galle">Galle</option>
                    <option value="Jaffna">Jaffna</option>
                    <option value="Kandy">Kandy</option>
                     <option value="Kurunegala">Kurunegala</option>
                    <option value="Gampaha">Gampaha</option>
                    <option value="Kegalle">Kegalle</option>
                    <option value="Nuwara Eliya">Nuwara Eliya</option>
                    <option value="Matale">Matale</option>
                </select>
            </div>    
            <div class="form-group">
                    <label for="email">Email address</label>
                    <input type="email" class="form-control" id="email" placeholder="name@example.com"
                            v-model="form.email" required>
            </div>
            <div class="form-group">
                    <label for="StartDate">Date *</label>
                    <input type="date" class="form-control" id="StartDate" v-model="form.StartDate" required>
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
    users: '',
    
    data(){
        return{
            posts: null,
            form: {
                name: '',
                bname: '',
                phonecode: '',
                phonenumber: '',
                AccAddress1: '',
                AccAddress2: '',
                AccDistrict: '',
                AccCity: '',
                email: '',
                StartDate: '',
            }
        }
    
    },
    methods:{

        submitForm(){
             alert("Do you wish to proceed!");  

            axios.post('https://localhost:44394/api/accounts', this.form)                        //Calling post method from Client side
                 .then((res) => {
                     //  callback(null, { posts: res.data ,loading: false }) 
                      this.$router.push('/BillingPage')
                      

                 })
                 .catch((error) => {
                     // error.response.status Check status code
                 }).finally(() => {
                     //Perform action in always
                    // alert("Do you wish to proceed!");  
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

