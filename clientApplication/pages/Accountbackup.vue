<template> 
<!-- In this file get data from the web api using sql queries.  -->
<div class="st1">
  <b-container fluid>
        <!-- <Logo /> -->
        <h1 class="title">testapplication - E_COM</h1>
        <div class="mt-3">
            <b-button-group>       
            <b-button variant="success">Admin Page</b-button>
            <b-button href="AccountDetailsPage" variant="info">User Registration Page</b-button>  <!--  New page -->
            </b-button-group>
        </div>
        <!-- <div>
            <label for="SearchAccount">Search Account</label>
            <input type="text" id="id" v-model="id">
        </div> -->
    <div>
        <table class="table">
        <thead>
            <tr scope="col">
            <th></th>
            <th>Name</th>
            <th>Bill ID</th>
            <th>Shipping ID</th>
            <th>Email</th>
            <th>Monthly Email</th>
            <th>Phone Code</th>
            <th>Phone Number</th>
            <th>Account Address</th>
            <th></th>
            <th>District</th>
            <th>City</th>
            <th>Billing Address</th>
            <th></th>
             <th>Shipping Address </th>
             <th></th>
             <th>Request </th>
             <th>Date </th>
            </tr>
        </thead>
        <tbody>
            <tr scope="row" v-for="(user, index) in posts" :key="user.Acc_ID">
            <td>{{ index + 1 }}</td>
            <td>{{ user.Name}}</td>
            <td>{{ user.Bill_ID}}</td>
            <td>{{ user.Ship_ID}}</td>
            <td>{{ user.Email}}</td>
            <td>{{ user.Email_Sub}}</td>
            <td>{{ user.Phone_Code}}</td>
            <td>{{ user.Phone_Number}}</td>
            <td>{{ user.Acc_Address1}}</td>
            <td>{{ user.Acc_Address2}}</td>
            <td>{{ user.Acc_District}}</td>
            <td>{{ user.Acc_City}}</td>
            <td>{{ user.Bill_Address1}}</td>
            <td>{{ user.Bill_Address2}}</td>
            <td>{{ user.Ship_Address1}}</td>
            <td>{{ user.Ship_Address2}}</td> 
            <td>{{ user.Request}}</td>                     
            <td>{{ user.Start_Date}}</td>              
            <!-- <td>{{ user.Bill_ID}}</td> -->
            </tr>
        </tbody>
        </table>   
    </div>
        <NuxtLink to="AccountDetailsPage">Account Information Page</NuxtLink>
         <!-- <NuxtLink to="new">Account new</NuxtLink> -->
  </b-container>
</div>     
</template>

<script>
import axios from 'axios';

var users;
export default {
    name: 'consume-rest-api',
    data(){
        return{
            posts: null
        }
    },
    data2(){    return{
            posts2: null,
            name2:null
        }
    },
    created() {
        axios.get(`https://localhost:44394/api/account`)                       //Calling get method from Client side
            .then(response => {
                this.posts = response.data    
                users = response['data']     
            })
            .catch(e => {
                console.log("Error Please check the connection")  //Display error msg in console

            });
    },
   
}
</script>

<style>
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
</style>
