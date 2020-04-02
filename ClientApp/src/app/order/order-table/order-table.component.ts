import { OrderSseService } from './../../services/sse.service';
import { OrderHttpService } from './../../services/order-http.service';
import { Component, OnInit } from '@angular/core';
import {formatDate} from './../util';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-table',
  templateUrl: './order-table.component.html',
  styleUrls: ['./order-table.component.css']
})
export class OrderTableComponent implements OnInit {

  orders: Array<any>;

  constructor(private orderService: OrderHttpService, private router: Router) {


  }


    ngOnInit() {
        this.orderService.getOrders().subscribe((response) => {

            const processOrder = (order) => {
                order.orderDate = formatDate(order.orderDate);
                order.shippedDate = formatDate(order.shippedDate);
                order.requiredDate = formatDate(order.requiredDate);
                return order;
            };

            let orders = response.value;
            if (orders && orders instanceof Array) {
                this.orders = orders.map(processOrder)  || [];
            }

  });
}


  navigateToOrderDetails(order) {
    this.router.navigate(['orders', order.id]);
   }

}
