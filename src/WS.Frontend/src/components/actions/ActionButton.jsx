const ActionButton = ({ icon, text, action }) => {
    const handleClick = () => {
        if (action) {
            action();
        }
    };

    return (
        <div onClick={handleClick} className="action-button">
            {icon}
            {text && <div className="action-button-text">{text}</div>}
        </div>
    );
};

export default ActionButton;
