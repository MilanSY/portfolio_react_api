import React from 'react';
import { useForm } from 'react-hook-form';
import { object, string, safeParse } from 'valibot';
import { X } from 'lucide-react';
import { useAuth } from '../contexts/AuthContext';

interface LoginModalProps {
    isOpen: boolean;
    onClose: () => void;
}

const LoginSchema = object({
    email: string([]),
    password: string([]),
});

const LoginModal: React.FC<LoginModalProps> = ({ isOpen, onClose }) => {
    const { login } = useAuth();
    const {
        register,
        handleSubmit,
        setError,
        formState: { errors },
    } = useForm();

    const onSubmit = async (data: any) => {
        // Validation with valibot
        const result = safeParse(LoginSchema, data);
        if (!result.success) {
            result.error.issues.forEach((issue) => {
                if (issue.path) {
                    setError(issue.path.join("."), {
                        type: "manual",
                        message: issue.message,
                    });
                }
            });
            return;
        }

        const success = await login(data.email, data.password);
        if (success) {
            onClose();
        } else {
            setError('root', {
                type: 'manual',
                message: 'Invalid email or password',
            });
        }
    };

    if (!isOpen) return null;

    return (
        <div className="fixed inset-0 bg-black/50 flex items-center justify-center z-50">
            <div className="bg-white rounded-lg p-6 w-full max-w-md">
                <div className="flex justify-between items-center mb-4">
                    <h2 className="text-2xl font-bold">Login</h2>
                    <button
                        onClick={onClose}
                        className="p-2 hover:bg-gray-100 rounded-full"
                    >
                        <X size={24} />
                    </button>
                </div>

                <form onSubmit={handleSubmit(onSubmit)} className="space-y-4">
                    <div>
                        <label htmlFor="email" className="block text-sm font-medium text-gray-700">
                            Email
                        </label>
                        <input
                            type="email"
                            {...register('email')}
                            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500"
                        />
                        {errors.email && (
                            <p className="mt-1 text-sm text-red-600">{String(errors.email?.message)}</p>
                        )}
                    </div>

                    <div>
                        <label htmlFor="password" className="block text-sm font-medium text-gray-700">
                            Password
                        </label>
                        <input
                            type="password"
                            {...register('password')}
                            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500"
                        />
                        {errors.password && (
                            <p className="mt-1 text-sm text-red-600">{String(errors.password?.message)}</p>
                        )}
                    </div>

                    {errors.root && (
                        <p className="text-sm text-red-600">{errors.root.message}</p>
                    )}

                    <button
                        type="submit"
                        className="w-full px-4 py-2 bg-blue-600 text-white rounded-lg hover:bg-blue-700 transition-colors"
                    >
                        Login
                    </button>
                </form>
            </div>
        </div>
    );
};

export default LoginModal;