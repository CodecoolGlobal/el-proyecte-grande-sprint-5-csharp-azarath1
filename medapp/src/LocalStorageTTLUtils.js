import React from 'react';
import Countdown from 'react-countdown';

export const  setWithExpiry= (userData) => {
	if(userData.error){
		return;
	}
	const item = {
		token: userData.token,
		id: userData.id,
		userRole: userData.userRole,
		expiry: userData.tokenExpirationTime,
	}
	localStorage.setItem("currentUser", JSON.stringify(item))
}
export const getWithExpiry=()=> {
	const itemStr = localStorage.getItem("currentUser")
	// if the item doesn't exist, return null
	if (!itemStr) {
		return null
	}
	const item = JSON.parse(itemStr)
	const now = new Date()
	// compare the expiry time of the item with the current time
	if (now.getTime() > item.expiry) {
		// If the item is expired, delete the item from storage
		// and return null
		localStorage.removeItem("currentUser")
		let fresh = window.confirm("Your session expired!");
		if (fresh === true) {
			window.location.href = "/Login";
                setTimeout(() => {
                    window.location.reload();    
                  }, 500);
			
		} else {
			window.location.href = "/";
                setTimeout(() => {
                    window.location.reload();    
                  }, 500);
		}
		return null
	}
	return item
}

export const Timer = ({LT})=>{
	return(
			  <Countdown
				date={LT}
				renderer={Renderer}
			  />	
	)
}

// Renderer callback with condition 
const Renderer = ({ hours, minutes, seconds, completed }) => {
	if (completed) {
		localStorage.removeItem("currentUser")
		window.location.href = "/Login";
                setTimeout(() => {
                    window.location.reload();    
                  }, 500);
	  } else {
		// Render a countdown
		return <span style={{color:'red'}}>{hours}:{minutes}:{seconds}</span>;
	  }
	};