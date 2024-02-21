import { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronDown, faChevronUp } from '@fortawesome/free-solid-svg-icons';

const SidebarFilter = () => {
    const [kategoriOpen, setKategoriOpen] = useState(false);
    const [signalordOpen, setSignalordOpen] = useState(false);

    return (
        <div className="sidebar">
            <span className="sidebar-header">Filter</span>
            <div className="sidebar-collapse">
                <span onClick={() => setKategoriOpen(!kategoriOpen)}>
                    Kategori{' '}
                    <FontAwesomeIcon icon={kategoriOpen ? faChevronUp : faChevronDown} className="sidebar-icon" />
                </span>
                {kategoriOpen && (
                    <div>
                        <label className="sidebar-collapse-content">
                            <input type="checkbox" />
                            Fysiske
                        </label>
                        <label className="sidebar-collapse-content">
                            <input type="checkbox" />
                            Miljø
                        </label>
                        <label className="sidebar-collapse-content">
                            <input type="checkbox" />
                            Sundhedsmæssige
                        </label>
                    </div>
                )}
            </div>
            <div className="sidebar-collapse">
                <span onClick={() => setSignalordOpen(!signalordOpen)}>
                    Signalord{' '}
                    <FontAwesomeIcon icon={signalordOpen ? faChevronUp : faChevronDown} className="sidebar-icon" />
                </span>
                {signalordOpen && (
                    <div>
                        <label className="sidebar-collapse-content">
                            <input type="checkbox" />
                            Fare
                        </label>
                        <label className="sidebar-collapse-content">
                            <input type="checkbox" />
                            Advarsel
                        </label>
                    </div>
                )}
            </div>
        </div>
    );
};

export default SidebarFilter;
