import { Component, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';
import { CommonModule } from "@angular/common";
import { AuthService } from "../../services/auth.service";
import { Router } from '@angular/router';  // Dodane

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']  // Zmienione na styleUrls
})
export class TaskListComponent implements OnInit {
  tasks: any[] = [];

  constructor(
    private taskService: TaskService,
    public authService: AuthService,
    private router: Router  // Dodane
  ) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.taskService.getTasks().subscribe(
      (data) => {
        this.tasks = data;
      },
      (error) => {
        console.error('Error loading tasks:', error);
      }
    );
  }

  deleteTask(id: number): void {
    this.taskService.deleteTask(id).subscribe(() => {
      this.tasks = this.tasks.filter(task => task.id !== id);
    });
  }

  addTask(): void {
    this.router.navigate(['/tasks/form']);
  }

  editTask(task: any): void {
    this.router.navigate(['/tasks/form', task.id]);
  }

  onLogout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);  // Przekierowanie po wylogowaniu
  }
}
