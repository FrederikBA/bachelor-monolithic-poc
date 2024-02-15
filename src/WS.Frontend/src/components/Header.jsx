import React, { useState } from 'react';
import Dropdown from 'react-bootstrap/Dropdown';

const Header = () => {
    const [activeItem, setActiveItem] = useState("SEA HEALTH & WELFARE APPLICATIONS");

    const handleSelect = (eventKey) => {
        setActiveItem(eventKey);
    };

    return (
        <div className="header">
            <Dropdown onSelect={handleSelect}>
                <Dropdown.Toggle className="nav-dropdown" variant="success" id="dropdown-basic">
                    <img src="/icons/seahealthicon.svg" alt="Sea Health Icon" className="icon" />
                    SEA HEALTH & WELFARE <span className="bold">APPLICATIONS</span>
                </Dropdown.Toggle>

                <Dropdown.Menu className="nav-dropdown-menu">
                    <Dropdown.Item eventKey="SEA HEALTH & WELFARE APPLICATIONS">
                        <img src="/icons/seahealthicon.svg" alt="Sea Health Icon" className="icon" />
                        SEA HEALTH & WELFARE <span className="bold">APPLICATIONS</span>
                    </Dropdown.Item>
                    <Dropdown.Item eventKey="Chemicals">Chemicals</Dropdown.Item>
                    <Dropdown.Item eventKey="Warning Sentences">Warning Sentences</Dropdown.Item>
                </Dropdown.Menu>
            </Dropdown>
        </div>
    );
};

export default Header;
