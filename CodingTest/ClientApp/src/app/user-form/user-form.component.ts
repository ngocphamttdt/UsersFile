import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html'
})
export class UserFormComponent implements OnInit {

  title = 'app-user';
  userForm: FormGroup


  @Output() refreshUserList = new EventEmitter()

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.createUserForm()
  }

  createUserForm() {
    this.userForm = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    this.userService.submitUserInformation(this.userForm.value).subscribe(
      (response) => {
        alert('successful')
        this.refreshUserList.emit("")
      },
      (error) => alert('error')
    )
  }
}

