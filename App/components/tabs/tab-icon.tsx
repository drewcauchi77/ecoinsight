import Ionicons from '@expo/vector-icons/Ionicons';
import { type I_TabItemProps } from '@/definitions/interfaces';

const TabIcon: React.FC<I_TabItemProps> = ({ icon, color = '#fff' }) => {
    return (
        <Ionicons name={icon} size={20} color={color} />
    );
};

export default TabIcon;