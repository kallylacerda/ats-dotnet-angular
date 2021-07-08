import { Component } from '@angular/core';
import { PoNavbarItem } from '@po-ui/ng-components';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  public readonly items: Array<PoNavbarItem> = [
    { label: 'Home', link: '/' },
    { label: 'Candidatos', link: '/candidatos' },
  ];

  public readonly logo: string = '../assets/ats-logo.png';
}
