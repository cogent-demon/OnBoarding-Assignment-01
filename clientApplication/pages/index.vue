<template>
<div class="st1">
  <b-container fluid>
        <!-- <Logo /> -->
        <h1 class="title">testapplication - E_COM</h1>
        <div class="mt-3">
            <b-button-group>       
            <b-button variant="success">Admin Page</b-button>
            <b-button href="AccountDetailsPage" variant="info">User Registration Page</b-button>
            </b-button-group>
        </div>
    <div>
      <pre>{{posts}}</pre>
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
            <th>Billing Address</th>
             <th>Shipping Address </th>
             <th>Shipping Address </th>
             <th>Request </th>
             <th>Date </th>
            </tr>
        </thead>
<!-- Getting data into a table using axios  -->
        <tbody>
            <tr scope="row" v-for="(user, index) in posts" :key="user.Acc_ID">
            <td>
            <pre>{{user.Billings[0]}}</pre></td>
            <td>{{ index + 1 }}</td>
            <td>{{ user.Name}}</td>
            <!-- <td>{{ user.Billings[0].[{"BillId"]}} -->
            <!-- <td>{{ user.Shippngs[0]['ShipId']}}</td> -->
            <td>{{ user.Email}}</td>
            <td>{{ user.EmailSub}}</td>
            <td>{{ user.PhoneCode}}</td>
            <td>{{ user.PhoneNumber}}</td>
            <td>{{ user.AccAddress1}}</td>
            <td>{{ user.AccAddress2}}</td>
            <td>{{ user.AccDistrict}}</td>
            <td>{{ user.AccCity}}</td>
            <!-- <td>{{ user.BillAddress1}}</td> -->
            <!-- <td>{{ user.Billings[0]["BillAddress1"]}}</td> -->
            <td>{{ user.ShipAddress1}}</td>
            <td>{{ user.ShipAddress2}}</td> 
            <td>{{ user.Request}}</td>                     
            <td>{{ user.StartDate}}</td>         
      

            <!-- <td>{{ user.Bill_ID}}</td> -->

            </tr>
        </tbody>
        </table>   
    </div>
      <NuxtLink to="AccountDetailsPage">Account Information Page</NuxtLink><br>     <!--Link to next page -->
         <NuxtLink to="Accountbackup">Backup</NuxtLink>
  </b-container>
</div>     
</template>

<script>
// Importing axios to perform http methods
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
    created() { //Get method axios 
        axios.get(`https://localhost:44394/api/accounts`)            
            .then(response => { 
                // JSON responses are automatically parsed.
                this.posts = response.data    
                users = response['data']     
            })
            .catch(e => {
                console.log("Error Please check the connection")  

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
