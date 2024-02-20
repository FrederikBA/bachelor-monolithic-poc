import { ReactComponent as EditIcon } from "../../assets/editicon.svg";
import { ReactComponent as BackIcon } from "../../assets/backicon.svg";
import ActionButton from "./ActionButton";
import ActionBarDivision from "./ActionBarDivision"

const ActionBarWarningSentencesView = ({ editAction, backAction }) => {
    return (
        <div className="action-bar" style={{ display: 'flex', justifyContent: 'flex-end', alignItems: 'center' }}>
            <ActionButton icon={<EditIcon />} text="Rediger" action={editAction} />
            <ActionBarDivision />
            <ActionButton icon={<BackIcon />} text="Tilbage" action={backAction} />
        </div>
    );
}

export default ActionBarWarningSentencesView;

