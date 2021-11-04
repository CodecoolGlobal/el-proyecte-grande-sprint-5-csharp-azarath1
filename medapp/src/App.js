import './App.css';
import {Home} from './Home';
import {Navigation} from './Navigation';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import { PatientRegistration } from './PatientRegistration';
import { DoctorRegistration } from './DoctorRegistration';
import { LoginModal } from './LoginModal';
import { DoctorLogin } from './DoctorLogin';
import { PatientLogin } from './PatientLogin';
import PatientPage from './PatientDetails';
import DoctorsOwnPatientsPage from './DoctorsOwnPatients';
import AllPatientsPage from './AllPatientsPage';
  
function App() {
  return (
    <BrowserRouter>
    <div className="container">
     <h3 className="m-3 d-flex justify-content-center">
       MedApp
     </h3>
     <Navigation />
     <Switch>
       <Route path='/' component={Home} exact/>
       <Route path='/personal' component={PatientPage}/>
       <Route path='/patientRegistration' component={PatientRegistration}/>
       <Route path='/doctorRegistration' component={DoctorRegistration} />
       <Route path='/login' component={LoginModal}/>
       <Route path='/doctorLogin' component={DoctorLogin} />
       <Route path='/patientLogin' component={PatientLogin} />
       <Route path='/allpatients' component={AllPatientsPage} />
       <Route path='/mypatients' component={DoctorsOwnPatientsPage} />
     </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;
