export const  setWithExpiry= (userData) => {
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
		return null
	}
	return item
}