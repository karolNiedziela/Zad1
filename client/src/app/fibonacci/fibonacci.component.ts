import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Coefficient } from '../models/coefficient';
import { FibonacciServiceService } from '../services/fibonacci-service.service';

@Component({
  selector: 'app-fibonacci',
  templateUrl: './fibonacci.component.html',
  styleUrls: ['./fibonacci.component.css'],
})
export class FibonacciComponent implements OnInit {
  indexForm: FormGroup;
  coefficents: Coefficient[] = [];
  values: any[] = [];

  constructor(private fibonacciServiceService: FibonacciServiceService) {
    this.indexForm = new FormGroup({
      index: new FormControl('', [
        Validators.required,
        Validators.max(20),
        Validators.min(1),
      ]),
    });
  }

  ngOnInit(): void {
    this.refreshData();
  }

  refreshData() {
    this.fibonacciServiceService
      .getFromSql()
      .subscribe((coefficents) => (this.coefficents = coefficents));

    this.fibonacciServiceService
      .getFromRedis()
      .subscribe((values) => (this.values = values));
  }

  get index() {
    return this.indexForm.get('index');
  }

  onSubmit(): void {
    const value = this.indexForm.get('index')!.value;
    this.fibonacciServiceService.post(value).subscribe(() => {
      this.refreshData();
    });
  }
}
