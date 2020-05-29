import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Maintenance } from '../model/maintenance';
import { GenericRest } from './generic-rest.service';

@Injectable({
  providedIn: 'root',
})
export class MaintenanceService extends GenericRest<Maintenance> {
  private readonly maintenanceUrl = 'api/maintenace';
  constructor(protected http: HttpClient) {
    super(http, 'api/maintenance');
  }

  // public getMaintenaceRequests(): Observable<Maintenance[]> {
  //   return this.http
  //     .get<Maintenance[]>(this.maintenanceUrl)
  //     .pipe(catchError(handleError('getMaintenaceRequets', [])));
  // }

  // public getTenant(id: number): Observable<Maintenance> {
  //   return this.http
  //     .get<Maintenance>(`${this.maintenanceUrl}/${id}`)
  //     .pipe(catchError(handleError<Maintenance>('getTenant', undefined)));
  // }
}