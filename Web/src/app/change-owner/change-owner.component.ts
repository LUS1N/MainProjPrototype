import { OwnersService } from '../owners.service';
import { Owner } from '../models/owner';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TypeaheadModule, TypeaheadMatch } from 'ng2-bootstrap/ng2-bootstrap';

@Component({
    selector: 'app-change-owner',
    templateUrl: './change-owner.component.html'
})
export class ChangeOwnerComponent implements OnInit {

    @Input() owner: Owner;
    selectOwner = new Owner();
    @Output() onOwnerSelect = new EventEmitter<number>();
    owners: Owner[];

    editing: boolean = false;

    flipEditing() {
        this.editing = !this.editing;
    }
    constructor(private ownerService: OwnersService) { }

    ngOnInit() {
        this.ownerService.getOwners().subscribe(ownrs => this.owners = ownrs);
    }

    typeaheadOnSelect(event) {
        this.selectOwner = event.item;
    }

    saveOwner() {
        this.onOwnerSelect.emit(this.selectOwner.id);
        this.owner = this.selectOwner;
        this.flipEditing();
    }
}
