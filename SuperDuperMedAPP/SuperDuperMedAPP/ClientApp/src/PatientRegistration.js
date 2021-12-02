import React from 'react';
import { useState } from 'react';
import { useHistory } from "react-router-dom";
import { setWithExpiry } from './LocalStorageTTLUtils.js';
import { Button } from "react-bootstrap";

function PatientRegistration() {
    const history = useHistory();
    const [socialSecurityNumber, setSecurityNumber] = useState(99999999);
    const [name, setName] = useState("Your name");
    const [DateOfBirth, setBirthDate] = useState("1990-01-01");
    const [email, setEmail] = useState("youremail@email.com");
    const [phoneNumber, setPhoneNumber] = useState(99999999);
    const [userName, setUserName] = useState("Username");
    const [password, setPassword] = useState("Password");

    function handleSubmit(event) {
        event.preventDefault();
        fetch('register/patient', {

            method: 'post',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "SocialSecurityNumber": socialSecurityNumber,
                "Name": name,
                "DateOfBirth": DateOfBirth,
                "Email": email,
                "PhoneNumber": phoneNumber,
                "Username": userName,
                "HashPassword": password,
                "Role": 'patient'
            }),
        })
            .then(res => res.json())
            .then((result) => {
                if (result.error) {
                    alert(result.error)
                    window.location.reload();
                    return;
                }
                setWithExpiry(result);
                alert('Successfully registered');
                history.push("/");
                setTimeout(() => {
                    window.location.reload();
                }, 1000);

            },
                (error) => {
                    alert('Failed registration');
                })
    }

    return (
        <div className="login-page">
            <div className="form">
                <form className="login-form" action="submit">
                    <div className="flex-container">

                        <div className="flex-child">
                            <div>
                                <label className="login-label">
                                    Social Security Number:
                                </label>
                                <br />
                                <input
                                    name="socialSecurityNumber"
                                    type="number"
                                    placeholder="000999000"
                                    onChange={event => setSecurityNumber(event.target.value)}
                                />
                            </div>
                            <div>
                                <label className="login-label">
                                    Name:
                                </label>
                                <br />
                                <input
                                    name="name"
                                    type="textarea"
                                    placeholder="Example Béla"
                                    onChange={event => setName(event.target.value)} />
                            </div>
                            <div>
                                <label className="login-label">
                                    Date of Birth:
                                </label>
                                <br />
                                <input
                                    name="dateOfBirth"
                                    type="date"
                                    placeholder="1991.01.01"
                                    onChange={event => setBirthDate(event.target.value)} />
                            </div>
                            <div>
                                <label className="login-label">
                                    Email:
                                </label>
                                <br />
                                <input
                                    name="email"
                                    type="textarea"
                                    placeholder="mail@mail.com"
                                    onChange={event => setEmail(event.target.value)} />
                            </div>
                        </div>

                        <div className="flex-child">
                            <div>
                                <label className="login-label">
                                    Phone Number:
                                </label>
                                <br />
                                <input
                                    name="phoneNumber"
                                    type="textarea"
                                    placeholder="+36304443333"
                                    onChange={event => setPhoneNumber(event.target.value)} />
                            </div>
                            <div>
                                <label className="login-label">
                                    Username:
                                </label>
                                <br />
                                <input
                                    name="username"
                                    type="textarea"
                                    placeholder="SnoopDoge"
                                    onChange={event => setUserName(event.target.value)} />
                            </div>
                            <div>
                                <label className="login-label">
                                    Password:
                                </label>
                                <br />
                                <input
                                    name="password"
                                    type="password"
                                    onChange={event => setPassword(event.target.value)}
                                />
                            </div>
                        </div>
                    </div>
                    <br />
                    <Button variant="success" type="submit" onClick={handleSubmit}>Submit</Button>
                </form>
            </div>
        </div>
    );
}

export default PatientRegistration;