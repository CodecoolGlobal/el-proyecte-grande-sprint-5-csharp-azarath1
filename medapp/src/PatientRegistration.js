import React from 'react';
import { useState } from 'react';
// import { Form, Button } from 'react-bootstrap';
// import { BehaviorSubject } from 'rxjs';
// const currentUserSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('currentUser')));
import { useHistory } from "react-router-dom";
import{setWithExpiry} from './LocalStorageTTLUtils.js';


function PatientRegistration() {
    const history = useHistory();
    const [socialSecurityNumber, setSecurityNumber] = useState(99999999);
    const [name, setName] = useState("Your name");
    const [DateOfBirth, setBirthDate] = useState("1990-01-01");
    const [email, setEmail] = useState("youremail@email.com");
    const [phoneNumber, setPhoneNumber] = useState(99999999);
    const [userName, setUserName] = useState("Username");
    const [password, setPassword] = useState("Password");



    

}




export default PatientRegistration;