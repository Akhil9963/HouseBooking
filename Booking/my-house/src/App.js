import React,{useState} from 'react';
import LoginForm from './components/LoginForm';
function App(){
  const adminUser={
    email:"admin@gmail.com",
    password:"12345"
  }
  const[user,setUser]=useState({name:"",email:""});
  const[erroe,setError]=useState("");
  const Login=details=>{
    console.log(details);
    if(details.email==adminUser.email&&details.password==adminUser.password){
    console.log("Logged in");
    setUser({
      name:details.name,
      email:details.email
    });
  } else {
    
      console.log("Incorrect email or password!");
      setError("Incorrect email or password!");
    }
  }
  const Logout=()=>{
    setUser({name:"",email:""});
  }
  return(
    <div className="App">
      {(user.email !="")?(
        <div className="Welcome to HouseBooking">
          <h2>HouseBooking,<span>{user.name}</span></h2>
          <button onClick={Logout}>Logout</button>
          </div>
      ):(
        <LoginForm Login={Login}error={erroe}/>
      )}
      </div>
      );
}
export default App;