import './App.css';
import './PatientDetails.js';
import {Home} from './Home';
import {Signup} from './Signup';
import {Navigation} from './Navigation';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import { Medicine } from './Medicine';
import PatientPage from './PatientDetails.js';
// import { PatientMedications } from './PatientMedications';
  
function App() {
  return (
    <BrowserRouter>
    <div className="container">
     <h3 className="m-3 d-flex justify-content-center">
       MedApp
     </h3>
     <PatientPage></PatientPage>
     <Navigation/>

     <Switch>
       <Route path='/' component={Home} exact/>
       <Route path='/signup' component={Signup}/>
       <Route path='/medicine' component={Medicine}/>
     </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
