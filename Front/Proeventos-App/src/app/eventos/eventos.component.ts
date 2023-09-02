import { Component } from '@angular/core'
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent {
  public eventos: any;

  constructor(private http: HttpClient){}

  ngOnInit(){
    this.getEventos()
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/Evento').subscribe({
      next: (res) => {
        this.eventos = res
        console.log(res)
      },
      error: (err) =>  console.log(err)
  })
  }
}
