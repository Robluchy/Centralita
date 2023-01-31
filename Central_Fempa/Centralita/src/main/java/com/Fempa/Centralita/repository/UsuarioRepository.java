package com.Fempa.Centralita.repository;
import com.Fempa.Centralita.model.Usuario;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

@RepositoryRestResource(collectionResourceRel = "users", path = "users")
public interface UsuarioRepository extends JpaRepository<Usuario, Integer> {
    Usuario findById(Long id);
    Usuario findByEmail(String email);
}
