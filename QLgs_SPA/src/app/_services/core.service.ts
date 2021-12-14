
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

// DTOs usados como parametros

@Injectable({
  providedIn: 'root'
})
export class CoreService {
  baseUrl = environment.apiurl;

constructor(private http: HttpClient) { }

  getDataCliente(codCliente: string) {
    const url = this.baseUrl + codCliente;

    return this.http.get(url);
  }

 /*  Ejemplo de Post 
  addAuthorizedCapacity(startDate, endDate, percentage, people) {

    const url = this.baseUrl + 'capacity/autorizedCapacities';

    const requestData = {
      startDate,
      endDate,
      capacity: people,
      percentageCapacity: percentage
    };

    return this.http.post(url, requestData);

  }
*/

/* Ejemplo de Put
updateMemberData(memberData: any) {

  const url = this.baseUrl + 'members/' + memberData.userId;

  return this.http.put(url, memberData);

}
*/

/* Ejemplo de Delete
deleteMemberDate(userId: any, date: any, hour: any) {

  const url = this.baseUrl + 'members/' + userId + '/schedule/' + date + '/' + hour;

  console.log(url);

  return this.http.delete(url);

}
*/

  getCompanyList() {
    return [
      { "id": 1, "displayName": "Qbic", "logo": "../../assets/img/LogoQbic.jpg"},
      { "id": 2, "displayName": "Pizza Hut", "logo": "../../assets/img/phlogo1.png"},
      { "id": 3, "displayName": "Starbuks", "logo": "../../assets/img/sblogo2.png"}
    ]
  }

  getMenuByCompany() {

    return [
      { "id": 1, "displayName": "CORE", "displayIcon": "", "url":"", "childs":[
        { "id": 2, "displayName": "Dashboard", "displayIcon": "fa fa-home", "url":"/home", "childs":[] },
        { "id": 18, "displayName": "Edo. Cta.", "displayIcon": "fa fa-home", "url":"/appCliente/edoCta", "childs":[] }
      ] },
      { "id": 3, "displayName": "INTERFACE", "displayIcon": "", "url":"", "childs":[
        { "id": 4, "displayName": "Layouts", "displayIcon": "fa fa-columns", "url":"", "childs":[
          { "id": 5, "displayName": "Static Navigation", "displayIcon": "", "url":"/home", "childs":[] },
          { "id": 6, "displayName": "Light Sidenav", "displayIcon": "", "url":"/home", "childs":[] }
        ] },
        { "id": 7, "displayName": "Pages", "displayIcon": "fa fa-book", "url":"", "childs":[
          { "id": 8, "displayName": "Authentication", "displayIcon": "", "url":"/home", "childs":[] },
          { "id": 9, "displayName": "Error", "displayIcon": "", "url":"/home", "childs":[] }
        ] }
      ] },
      { "id": 13, "displayName": "QLgs.EdoCta", "displayIcon": "", "url":"", "childs":[
        { "id": 14, "displayName": "Seguridad", "displayIcon": "fa fa-columns", "url":"", "childs":[
          { "id": 15, "displayName": "Nuevos Usuarios", "displayIcon": "", "url":"/form/users", "childs":[] },
          { "id": 16, "displayName": "Asignacion de Persmisos", "displayIcon": "", "url":"/home", "childs":[] }
        ] }
      ] },
      { "id": 10, "displayName": "ADDONS", "displayIcon": "", "url":"", "childs":[
        { "id": 11, "displayName": "Charts", "displayIcon": "fa fa-bars", "url":"/home", "childs":[] },
        { "id": 12, "displayName": "Tables", "displayIcon": "fa fa-table", "url":"/home", "childs":[] }
      ] }

    ]

  }


  getFormInfoByName(formName: string) {

    if(formName == "/form/users") {
      return {
        "formName": "Registro de Nuevos Usuarios",
        "path": ["QLgs.EdoCta", "Seguridad", "Nuevos Usuarios"],
        "notes": "Esta forma solo sirve para hacer la invitacion a nuevos usuarios",
        "notesType": "alert-info",
        "formTitle": "Invitacion de nuevos usuarios",
        "formIcon": "fa fa-user-plus",
        "footerNotes": "La tasa de usuarios usuarios que responden a la ivitacion por correo es del 80%",
        "componente":""
      }
    }

    if(formName == "/appCliente/edoCta") {
      return {
        "formName": "Estado de Cuenta del Cliente",
        "path": ["Lagsa", "Estado de Cuenta"],
        "notes": "Aqui puede consultar el ultimo pago hecho en su(s) terreno(s)/Casa(s) asi como realizar un pago al mismo.",
        "notesType": "alert-info",
        "formTitle": "Titulo de la Forma",
        "formIcon": "fa fa-user-plus",
        "footerNotes": "Notas del pie de pagina.",
        "componente":""
      }
    }

        
  }

}
