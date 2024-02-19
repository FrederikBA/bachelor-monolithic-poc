import React, { useState } from 'react';
import { NavLink } from 'react-router-dom';
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
                    <img src="/../src/assets/seahealthicon.svg" alt="Sea Health Icon" className="icon" />
                    SEA HEALTH & WELFARE <span className="bold">APPLICATIONS</span>
                </Dropdown.Toggle>

                <Dropdown.Menu className="nav-dropdown-menu">
                    <NavLink to="/" className="nav-link-custom">
                        <Dropdown.Item as="li" className="nav-dropdown-item" eventKey="SEA HEALTH & WELFARE APPLICATIONS">
                            <img src="/../src/assets/seahealthicon.svg" alt="Sea Health Icon" className="icon dropdown-item-icon" />
                            SEA HEALTH & WELFARE <span className="bold">APPLICATIONS</span>
                        </Dropdown.Item>
                    </NavLink>
                    <NavLink to="/chemicals" className="nav-link-custom">
                        <Dropdown.Item as="li" className="nav-dropdown-item nav-dropdown-item-bold" eventKey="CHEMICALS">
                            CHEMICALS
                        </Dropdown.Item>
                    </NavLink>
                    <NavLink to="/warningsentences" className="nav-link-custom">
                        <Dropdown.Item as="li" className="nav-dropdown-item nav-dropdown-item-bold" eventKey="WARNING SENTENCES">
                            WARNING SENTENCES
                        </Dropdown.Item>
                    </NavLink>
                </Dropdown.Menu>
            </Dropdown>
        </div>
    );
};

export default Header;
