const ActionButton = ({ icon, text, action, disabled }) => {
    const handleClick = () => {
        if (action && !disabled) {
            action();
        }
    };

    return (
        <div onClick={handleClick} className={`action-button ${disabled ? 'disabled' : ''}`}>
            {icon}
            {text && <div className="action-button-text">{text}</div>}
        </div>
    );
};

export default ActionButton;
