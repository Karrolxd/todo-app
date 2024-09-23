import { Component } from '@angular/core';
import { TaskService } from "../../services/task.service";
import { Router, ActivatedRoute } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './task-form.component.html',
  styleUrl: './task-form.component.css'
})
export class TaskFormComponent {
task: any = {
  title: '',
  description: '',
  dueDate: '',
  priority: ''
};
isEditMode = false;
taskId: number | null = null;

constructor(private taskService: TaskService, private router: Router, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      if (params['id']) {
        this.isEditMode = true;
        this.taskId += params['id'];
        this.loadTask();
      }
    })
  }

  loadTask(): void {
    if (this.taskId) {
      this.taskService.getTaskById(this.taskId). subscribe((task) => {
        this.task = task;
      })
    }
  }

  onSubmit(): void {
    if (this.isEditMode && this.taskId) {
      this.taskService.updateTask(this.taskId, this.task).subscribe(() => {
        this.router.navigate(['/tasks']);
      });
    } else {
      this.taskService.createTask(this.task).subscribe(() => {
        this.router.navigate(['/tasks']);
      });
    }
  }
}
