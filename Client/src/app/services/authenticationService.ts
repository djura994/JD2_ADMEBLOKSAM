 export class AuthService{

    loggedIn: boolean;

    constructor() {

    }

    logIn(): void {
        localStorage.setItem("token","sessionToken");
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