import { Component, Inject, Input, OnInit} from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";

@Component({
  selector: 'quiz-list',
  templateUrl: './quiz-list.component.html',
  styleUrls: ['./quiz-list.component.css']
})

export class QuizListComponent implements OnInit {
  @Input() class : string;
  title: string;
  selectedQuiz: IQuiz;
  quizzes: IQuiz[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string,
    private router: Router) {
  }

  ngOnInit() {

    console.log("Class " + this.class);
    var url = this.baseUrl + "api/quiz/";
    switch (this.class) {
    case "latest":
    default:
      this.title = "Latest";
      url += "Latest/";
      break;
    case "byTitle":
      this.title = "By Title";
      url += "byTitle";
      break;
    case "random":
      this.title = "Random";
      url += "Random";
      break;
    }

    this.http.get<IQuiz[]>(url).subscribe(result => {
      this.quizzes = result;
    }, error => console.error(error));
  }

  onSelect(quiz: IQuiz) {
    this.selectedQuiz = quiz;
    //console.log("quiz with Id "
    //  + this.selectedQuiz.id
    //  + " has been selected.");
    //console.log(this.baseUrl);
    //this.router.navigate(["/quiz", this.selectedQuiz.id]);
  }
}
