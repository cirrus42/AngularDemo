import { Component, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "quiz-list",
  template: './quiz-list.component.html',
  styleUrls: ['./quiz-list.component.css']
})

export class QuizListComponent {
  title: string;
  selectedQuiz: IQuiz;
  quizzes: IQuiz[];

  constructor(http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    this.title = "Latest Quizzes";
    var url = baseUrl + "api/quiz/Latest/";
    http.get<IQuiz[]>(url).subscribe(result => { this.quizzes = result; }, error => console.error(error));
  }

  onSelect(quiz: IQuiz) {
    this.selectedQuiz = quiz;
    console.log("quiz with id " + this.selectedQuiz.id + " has been selected.");
  }
}
