import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })

export class UserService {
  constructor(private http: HttpClient) {}

  submitUserInformation(param: any){
    return this.http.post("https://localhost:44348/api/user", param)
  }
  
  loadUsers(){
    return this.http.get("https://localhost:44348/api/user")
  }

}