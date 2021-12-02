import './App.css';
import Home from './Home';
import Navigation from './Navigation';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import PatientRegistration from './PatientRegistration';
import DoctorRegistration from './DoctorRegistration';
import Login from './Login';
import PersonalDetails from './DetailsPage';
import DoctorsOwnPatientsPage from './DoctorsOwnPatients';
import DoctorsPatientDetails from './DoctorsPatientDetails';
import AllPatientsPage from './AllPatientsPage';
import PatientMedications from './PatientMedications';
import FooterElement from './FooterElement';

function App() {
  return (
    <BrowserRouter>
      <div className="container">
        <Navigation />
        <Switch>
          <Route path='/' component={Home} exact />
          <Route path='/personal' component={PersonalDetails} />
          <Route path='/patientRegistration' component={PatientRegistration} />
          <Route path='/doctorRegistration' component={DoctorRegistration} />
          <Route path='/Login' component={Login} />
          <Route path='/mymedications' component={PatientMedications} />
          <Route path='/doctorLogin' component={Login} />
          <Route path='/patientLogin' component={Login} />
          <Route path='/allpatients' component={AllPatientsPage} />
          <Route path='/mypatients' component={DoctorsOwnPatientsPage} />
          <Route path='/doctorspatient' component={DoctorsPatientDetails} />

        </Switch>
        <FooterElement />
      </div>
    </BrowserRouter>
  );
}

export default App;
