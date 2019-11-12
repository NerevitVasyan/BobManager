import { Component, OnInit } from '@angular/core';
import { ToDo } from 'src/app/models/todo.model';
import { TodoService } from 'src/app/services/todo.service';

@Component({
  selector: 'app-to-do-list',
  templateUrl: './to-do-list.component.html',
  styleUrls: ['./to-do-list.component.css']
})
export class ToDoListComponent implements OnInit {

  todos: ToDo[];
  constructor(private todoService: TodoService) { }

  ngOnInit() {
    this.todoService.getToDos().subscribe(data => {
      this.todos = data;
    });
  }

}
