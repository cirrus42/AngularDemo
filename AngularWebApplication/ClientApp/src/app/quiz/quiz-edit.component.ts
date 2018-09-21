import { Component, Inject, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: "quiz-edit",
  templateUrl: './quiz-edit.component.html',
  styleUrls: ['./quiz-edit.component.css']
})
export class QuizEditComponent {

  title: string;
  quiz: IQuiz;
  editMode: boolean;

  constructor(private activatedRoute: ActivatedRoute,
    private router: Router,
    private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {

    this.quiz = <IQuiz>{};
    var id = this.activatedRoute.snapshot.params["id"];
 
    if (id) {
      this.editMode = true;
      var url = this.baseUrl + "api/quiz/" + id;

      this.httpClient.get<IQuiz>(url).subscribe(result => {
          this.quiz = result;
          this.title = "Edit - " + this.quiz.Title;
        },
        error => console.error(error));
    } else {
      this.editMode = false;
      this.title = "Create a new Quiz";
    }
  }

  onSubmit(quiz: IQuiz) {
    var url = this.baseUrl + "api/quiz";

    if (this.editMode) {
      this.httpClient
        .put<IQuiz>(url, quiz)
        .subscribe(result => {
          var v = result;
          console.log("Quiz " + v.Id + " has been updated.");
          this.router.navigate(["home"]);
        }, error => console.log(error));
    }
    else {
      this.httpClient
        .post<IQuiz>(url, quiz)
        .subscribe(result => {
          var v = result;
          console.log("Quiz " + v.Id + " has been created.");
          this.router.navigate(["home"]);
        }, error => console.log(error));
    }
  }

  onBack() {
    this.router.navigate(["home"]);
  }


}


