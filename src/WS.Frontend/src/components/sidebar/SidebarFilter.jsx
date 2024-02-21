import { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faChevronDown, faChevronUp } from '@fortawesome/free-solid-svg-icons';

const SidebarFilter = ({ onFilterChange, filters }) => {
    const [kategoriOpen, setKategoriOpen] = useState(false);
    const [signalordOpen, setSignalordOpen] = useState(false);

    const handleFilterToggle = (filterType) => {
        if (filterType === 'kategori') {
            setKategoriOpen(!kategoriOpen);
        } else if (filterType === 'signalord') {
            setSignalordOpen(!signalordOpen);
        }
    };

    const handleCheckboxChange = (filterType, filterName, isChecked) => {
        onFilterChange(filterType, filterName, isChecked);
    };

    return (
        <div className="sidebar">
            <span className="sidebar-header">Filter</span>
            <div className="sidebar-collapse">
                <span onClick={() => handleFilterToggle('kategori')}>
                    Kategori{' '}
                    <FontAwesomeIcon icon={kategoriOpen ? faChevronUp : faChevronDown} className="sidebar-icon" />
                </span>
                {kategoriOpen && (
                    <div>
                        <label className="sidebar-collapse-content">
                            <input
                                type="checkbox"
                                checked={filters.kategori.fysiske}
                                onChange={(e) => handleCheckboxChange('kategori', 'fysiske', e.target.checked)}
                            />
                            Fysiske
                        </label>
                        <label className="sidebar-collapse-content">
                            <input
                                type="checkbox"
                                checked={filters.kategori.sundhedsmæssige}
                                onChange={(e) => handleCheckboxChange('kategori', 'sundhedsmæssige', e.target.checked)}
                            />
                            Sundhedsmæssige
                        </label>
                        <label className="sidebar-collapse-content">
                            <input
                                type="checkbox"
                                checked={filters.kategori.miljø}
                                onChange={(e) => handleCheckboxChange('kategori', 'miljø', e.target.checked)}
                            />
                            Miljø
                        </label>
                    </div>
                )}
            </div>
            {/* <div className="sidebar-collapse">
                <span onClick={() => handleFilterToggle('signalord')}>
                    Signalord{' '}
                    <FontAwesomeIcon icon={signalordOpen ? faChevronUp : faChevronDown} className="sidebar-icon" />
                </span>
                {signalordOpen && (
                    <div>
                        <label className="sidebar-collapse-content">
                            <input
                                type="checkbox"
                                checked={filters.signalord.fare}
                                onChange={(e) => handleCheckboxChange('signalord', 'fare', e.target.checked)}
                            />
                            Fare
                        </label>
                        <label className="sidebar-collapse-content">
                            <input
                                type="checkbox"
                                checked={filters.signalord.advarsel}
                                onChange={(e) => handleCheckboxChange('signalord', 'advarsel', e.target.checked)}
                            />
                            Advarsel
                        </label>
                    </div>
                )}
            </div> */}
        </div>
    );
};

export default SidebarFilter;
