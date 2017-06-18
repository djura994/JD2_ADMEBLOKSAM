 export class AuthService{

    loggedIn: boolean;

    constructor() {

    }

    logIn(): void {
        
    }

    logOut(): void {
        localStorage.removeItem("token");
    }

    isLoggedIn(): boolean {
        if(localStorage.getItem("token") !== null)
            return true;
        else 
            return false;
    }
 }