import { Component } from "@angular/core";

@Component({
  selector: "app-root",
  template: `
    <nav class="navbar bg-dark mb-5">
      <div class="container-fluid">
        <span>
          <img
            class="navbar-brand"
            alt="Angular Logo"
            src="https://confitec.com.br/wp-content/uploads/2023/05/logos-confitec-white.png"
          />
        </span>
      </div>
    </nav>
    <div class="mx-5">
      <router-outlet></router-outlet>
    </div>
  `,
  styles: [],
})
export class AppComponent {
  title = "confitec-front";
}
