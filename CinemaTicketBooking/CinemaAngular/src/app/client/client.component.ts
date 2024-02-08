import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {

  readonly APIUrl = "http://localhost:5000/api/Client/";
  clients: any[] = [];
  clientId: string = '';
  clientFirstName: string = '';
  clientTelephoneNumber: string = '';
  clientEmail: string = '';

  constructor(private http: HttpClient) { }

  getAllClients() {
    this.http.get<any[]>(this.APIUrl + 'GetAllClients').subscribe(response => {
      this.clients = response;
    });
  }

  getClientById() {
    if (this.clientId && this.clientId.trim() !== '') {
      this.http.get<any>(`${this.APIUrl}GetClientById?id=${this.clientId}`).subscribe(response => {
        if (response && response.id) {
          this.clients = [response.result];
        } else {
          console.error('Nu s-au găsit date pentru clientul cu ID-ul ' + this.clientId);
        }
      });
    } else {
      console.error('ID-ul clientului nu e valid.');
    }
  }

  getClientByFirstName() {
    if (this.clientFirstName && this.clientFirstName.trim() !== '') {
      this.http.get<any>(`${this.APIUrl}GetClientByFirstName?firstName=${this.clientFirstName}`).subscribe(response => {
        if (response && Array.isArray(response)) {
          this.clients = response;
        } else {
          console.error('Nu s-au găsit date pentru clientul cu numele ' + this.clientFirstName);
        }
      });
    } else {
      console.error('Numele clientului nu este valid.');
    }
  }

  deleteAllClients() {
    this.http.delete(this.APIUrl + 'DeleteAllClients').subscribe(() => {
      this.getAllClients();
    });
  }

  deleteClientById() {
    if (this.clientId && this.clientId.trim() !== '') {
      this.http.delete<any>(`${this.APIUrl}DeleteClient?id=${this.clientId}`).subscribe(() => {
        this.getAllClients();
      });
    } else {
      console.error('ID-ul clientului pentru ștergere nu este valid.');
    }
  }

  createClient() {
    const newClient = {
      id: this.clientId,
      firstName: this.clientFirstName,
      telephoneNumber: this.clientTelephoneNumber,
      email: this.clientEmail
    };

    this.http.post<any>(`${this.APIUrl}CreateClient`, newClient).subscribe(() => {
      this.getAllClients();
    });
  }

  ngOnInit() {
    this.getAllClients();
  }
}
