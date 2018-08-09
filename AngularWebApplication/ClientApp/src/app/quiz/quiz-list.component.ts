import { Component, Inject } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'quiz-list',
  templateUrl: './quiz-list.component.html',
  styleUrls: ['./quiz-list.component.css']
})
export class QuizListComponent {
  title: string;
  selectedQuiz: IQuiz;
  quizzes: IQuiz[];
  theUrl: string;
  public forecasts: IWeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.title = "Latest Quizzes";
    var url = baseUrl + "api/quiz/Latest/";
    this.theUrl = url;

    //http.get<IQuiz[]>(url).subscribe(result => { this.quizzes = result; }, error => console.error(error));
    http.get<IWeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));

  }
}
