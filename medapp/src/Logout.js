import { useState, useEffect, } from 'react';

function Logout() {
  const [details, setDetails] = useState(null);
  const [userkey, type, id, _] = document.cookie.valueOf().split('=');

//   This is the way! - Logout function to delete local storage token.
//   function logout() {
//     // remove user from local storage to log user out
//     localStorage.removeItem('currentUser');
//     currentUserSubject.next(null);
// }
  useEffect(() => {
    getData();

    async function getData() {
      if (type === "patient") {
        const response = await fetch(process.env.REACT_APP_BASE_URL_PATIENT+id+"/logout", {credentials:'include'});
        const data = await response.json();
        setDetails(data);
        console.log(details);
    }
      else {
        const response = await fetch(process.env.REACT_APP_BASE_URL_DOCTOR+id+"/logout", {credentials:'include'});
        const data = await response.json();
        setDetails(data);
        console.log(details);
    }  
      
    }
  }, [details, userkey, type, id, _]);
  if(details){
    alert("You logged out successfuly!")
  }
}

export default Logout;