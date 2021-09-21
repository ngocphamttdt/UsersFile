import { Component } from '@angular/core';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  userList: any

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.loadUsers()
  }

  onRefreshUserList(){
    this.loadUsers()
  }

  loadUsers = () => {
    this.userService.loadUsers().subscribe(
      (response) => {
        this.userList = response
      },
      (error) => { }

    )
  }
}
