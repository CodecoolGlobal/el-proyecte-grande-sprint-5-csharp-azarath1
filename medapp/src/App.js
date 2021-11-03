import './App.css';
import {Home} from './Home';
import {Signup} from './Signup';
import {Navigation} from './Navigation';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
// import { Medicine } from './Medicine';
import { PatientRegistration } from './PatientRegistration';
import { DoctorRegistration } from './DoctorRegistration';
import { LoginModal } from './LoginModal';
import { DoctorLogin } from './DoctorLogin';
import { PatientLogin } from './PatientLogin';
import PatientPage from './PatientDetails';

  
function App() {
  return (
    <BrowserRouter>
    <div className="container">
     <h3 className="m-3 d-flex justify-content-center">
       MedApp
     </h3>
     <Navigation/>
     <Switch>
       <Route path='/' component={Home} exact/>
       <Route path='/signup' component={Signup}/>
       <Route path='/personal' component={PatientPage}/>
       <Route path='/patientRegistration' component={PatientRegistration}/>
       <Route path='/doctorRegistration' component={DoctorRegistration} />
       <Route path='/login' component={LoginModal}/>
       <Route path='/doctorLogin' component={DoctorLogin} />
       <Route path='/patientLogin' component={PatientLogin} />
     </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
